<template>    
    <div class="max-w-md flex flex-col h-full gap-3 p-5 rounded bg-white">
        <Dropdown v-model="selected" :options="algorithms" class="w-full" />
        
        <div v-if="selected" class="w-full">
            <component :is="selected" />
        </div>        

        <Textarea v-model="result" readonly rows="15" class="w-full basis-60 flex-grow" />
    </div>
</template>

<script>
import EllipticCurve from '../../components/EllipticCurve/Index.vue';
import ElGamal from '../../components/ElGamal/Index.vue';
import ExtendedGreatestCommonDivisor from '../../components/ExtendedGreatestCommonDivisor/Index.vue';
import FermantFactorization from '../../components/FermantFactorization/Index.vue';
import IsGenerator from '../../components/IsGenerator/Index.vue';
import LehmanPeraltPrimality from '../../components/LehmanPeraltPrimality/Index.vue';
import ModularExponentiation from '../../components/ModularExponentiation/Index.vue';
import PollardRhoAlgorithm from '../../components/PollardRhoAlgorithm/Index.vue';
import Rsa from '../../components/Rsa/Index.vue';
import ShamirProtocol from '../../components/ShamirProtocol/Index.vue';
import { computed } from 'vue';
import { useMainStore } from '../../store/mainStore';

export default {
    components: {
        EllipticCurve,
        ElGamal,
        ExtendedGreatestCommonDivisor,
        FermantFactorization,
        IsGenerator,
        LehmanPeraltPrimality,
        ModularExponentiation,
        PollardRhoAlgorithm,
        Rsa,
        ShamirProtocol
    },
    setup () {
        const mainStore = useMainStore();

        const algorithms = mainStore.algorithmKeys;
        const selected = computed({
            get: () => mainStore.selected,
            set: (value) => mainStore.selected = value
        });
        const result = computed(() => mainStore.algorithms[selected.value]?.result);             

        return {
            algorithms,
            selected,
            result
        }
    }
}
</script>
