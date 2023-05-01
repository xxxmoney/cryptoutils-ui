import { defineStore } from 'pinia'
import axios from 'axios'

export const useMainStore = defineStore('main', {
    state: () => {
        return {
            loaded: true,
            algorithms: {
                EllipticCurve: {
                    data: {
                        "normal": {
                            "sum": {
                                "curveA": null,
                                "curveB": null,
                                "curvePrime": null,
                                "firstPoint": {
                                    "x": null,
                                    "y": null
                                },
                                "secondPoint": {
                                    "x": null,
                                    "y": null
                                }
                            },
                            "alignson": {
                                "curveA": null,
                                "curveB": null,
                                "curvePrime": null,
                                "point": {
                                    "x": null,
                                    "y": null
                                }
                            }
                        },
                        "advanced": {
                            "sum": {
                                "curveA_G": null,
                                "curveB_G": null,
                                "polynomialBinary": null,
                                "irreduciblePolynomialBinary": null,
                                "n": null,
                                "firstPoint": {
                                    "x": null,
                                    "y": null
                                },
                                "secondPoint": {
                                    "x": null,
                                    "y": null
                                }
                            },
                            "multiply": {
                                "curveA_G": null,
                                "curveB_G": null,
                                "polynomialBinary": null,
                                "irreduciblePolynomialBinary": null,
                                "n": null,
                                "point": {
                                    "x": null,
                                    "y": null
                                },
                                "scalar": null
                            },
                            "alignson": {
                                "curveA_G": null,
                                "curveB_G": null,
                                "polynomialBinary": null,
                                "irreduciblePolynomialBinary": null,
                                "n": null,
                                "point": {
                                    "x": null,
                                    "y": null
                                }
                            }
                        }
                    },
                    result: null,
                    isValid: false
                },
                ElGamal: {
                    data: {
                        "encryption": {
                            "p": null,
                            "z": null,
                            "b": null,
                            "k": null,
                            "m": null
                        },
                        "decryption": {
                            "c": null,
                            "d": null,
                            "p": null,
                            "a": null
                        }
                    },
                    result: null,
                    isValid: false
                },
                ExtendedGreatestCommonDivisor: {
                    data: {
                        "number": null,
                        "prime": null
                    },
                    result: null,
                    isValid: false
                },
                FermantFactorization: {
                    data: {
                        "number": null
                    },
                    result: null,
                    isValid: false
                },
                IsGenerator: {
                    data: {
                        "normal": {
                            "p": null,
                            "numbers": [
                            ]
                        },
                        "advanced": {
                            "irreduciblePolynomialBinary": null,
                            "n": null,
                            "polynomialsBinary": [
                            ]
                        }
                    },
                    result: null,
                    isValid: false
                },
                LehmanPeraltPrimality: {
                    data: {
                        "examinedNumber": null,
                        "numbers": [
                        ]
                    },
                    result: null,
                    isValid: false
                },
                ModularExponentiation: {
                    data: {
                        "number": null,
                        "power": null,
                        "prime": null
                    },
                    result: null,
                    isValid: false
                },
                PollardRhoAlgorithm: {
                    data: {
                        "number": null,
                        "seed": null
                    },
                    result: null,
                    isValid: false
                },
                Rsa: {
                    data: {
                        "encryption": {
                            "m": null,
                            "n": null,
                            "e": null
                        },
                        "decryption": {
                            "m": null,
                            "n": null,
                            "d": null
                        },
                        "derivePrivateKeyFromModule": {
                            "n": null,
                            "e": null
                        },
                        "deriveKeysFromPublicExponent": {
                            "p": null,
                            "q": null,
                            "e": null
                        },
                        "deriveKeysFromPrivateExponent": {
                            "p": null,
                            "q": null,
                            "d": null
                        }
                    },
                    result: null,
                    isValid: false
                },
                ShamirProtocol: {
                    data: {
                    },
                    result: null,
                    isValid: false
                }
            },
            selected: null
        }
    },

    getters: {
        algorithmKeys: (state) => Object.keys(state.algorithms)
    },

    actions: {
        async getResultAsync() {
            if (!this.selected) {
                return;
            }

            try {
                this.loaded = false;
                const endpointName = '/api/Cryptoutils/Handle' + this.selected;
                const response = await axios.post(endpointName, this.algorithms[this.selected].data);

                if (response.data) {
                    this.algorithms[this.selected].result = response.data;
                }
            } finally {
                this.loaded = true;
            }
        }
    }
})