<template>
    <div class="custom-container">
        <div>
            <span class="p-float-label">
                <InputNumber id="number" :min="0" v-model="data.number" class="w-full" />
                <label for="number">Number</label>
            </span>
            
            <ErrorMessages :v="v$" field="number" />
        </div>

        <div>
            <span class="p-float-label">
                <InputNumber id="seed" :min="0" v-model="data.seed" class="w-full" />
                <label for="seed">Seed</label>
            </span>
            
            <ErrorMessages :v="v$" field="seed" />
        </div>
        
    </div>
</template>

<script>
import { useMainStore } from '../../store/mainStore';
import { useVuelidate } from '@vuelidate/core';
import { required } from '@vuelidate/validators'
import { computed, watch } from 'vue';

export default {
    name: 'PollardRhoAlgorithm',
    setup () {
        const mainStore = useMainStore();        
        const algo = computed(() => mainStore.algorithms.PollardRhoAlgorithm);
        const data = computed(() => algo.value.data);

        const rules = {
            number: { required },
            seed: { required }
        };

        const v$ = useVuelidate(rules, data);

        watch(() => v$.value.$invalid, (value) => {
            algo.value.isValid = !value;
        });

        return {
            data,
            v$
        }
    }
}
</script>
