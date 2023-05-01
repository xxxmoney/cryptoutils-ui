<template>
    <div class="custom-container">
        <div class="col-span-2">
            <span class="p-float-label">
                <InputNumber id="number" :min="0" v-model="data.number" class="w-full" />
                <label for="number">Number</label>
            </span>
            
            <ErrorMessages :v="v$" field="number" />
        </div>
    </div>
</template>

<script>
import { useMainStore } from '../../store/mainStore';
import { useVuelidate } from '@vuelidate/core';
import { required } from '@vuelidate/validators'
import { computed, watch } from 'vue';

export default {
    name: 'FermantFactorization',
    setup () {
        const mainStore = useMainStore();        
        const algo = computed(() => mainStore.algorithms.FermantFactorization);
        const data = computed(() => algo.value.data);

        const rules = {
            number: { required }
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

<style scoped>

</style>