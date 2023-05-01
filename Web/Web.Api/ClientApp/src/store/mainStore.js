import { defineStore } from 'pinia'

export const useMainStore = defineStore('main', {
    state: () => {
        return {
            loaded: false,
            algorithms: {
                EllipticCurve: {

                },
                ElGamal: {

                },
                ExtendedGreatestCommonDivisor: {

                },
                FermantFactorization: {

                },
                IsGenerator: {

                },
                LehmanPeraltPrimality: {

                },
                ModularExponentiation: {

                },
                PollardRhoAlgorithm: {

                },
                Rsa: {

                },
                ShamirProtocol: {

                }
            },
            selected: null
        }
    },

    getters: {
        algorithmKeys: (state) => Object.keys(state.algorithms)        
    },

    actions: {
        
    }
})