import { defineStore } from 'pinia'
import axios from 'axios'

export const useMainStore = defineStore('main', {
    state: () => {
        return {
            loaded: false,
            algorithms: {
                EllipticCurve: {
                    data: {
                    },
                    result: null,
                    isValid: false
                },
                ElGamal: {
                    data: {
                    },
                    result: null,
                    isValid: false
                },
                ExtendedGreatestCommonDivisor: {
                    data: {
                    },
                    result: null,
                    isValid: false
                },
                FermantFactorization: {
                    data: {
                    },
                    result: null,
                    isValid: false
                },
                IsGenerator: {
                    data: {
                    },
                    result: null,
                    isValid: false
                },
                LehmanPeraltPrimality: {
                    data: {
                    },
                    result: null,
                    isValid: false
                },
                ModularExponentiation: {
                    data: {
                    },
                    result: null,
                    isValid: false
                },
                PollardRhoAlgorithm: {
                    data: {
                    },
                    result: null,
                    isValid: false
                },
                Rsa: {
                    data: {
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
            if(!this.selected) {
                return;
            }

            const response = await axios.post('/api/Cryptoutils/Handle' + this.selected, this.algorithms[this.selected].data);
            
            if(response.data) {
                this.algorithms[this.selected].result = response.data;
            }
        }
    }
})