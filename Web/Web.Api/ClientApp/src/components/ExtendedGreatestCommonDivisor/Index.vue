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
                <InputNumber id="prime" :min="0" v-model="data.prime" class="w-full" />
                <label for="prime">Prime</label>
            </span>
        
            <ErrorMessages :v="v$" field="prime" />
        </div>

        <Button :disabled="!isCurrentValid" label="Process" class="col-span-2" @click="getResultAsync()" />
    </div>
</template>

<script>
import { useMainStore } from '../../store/mainStore';
import { useVuelidate } from '@vuelidate/core';
import { required } from '@vuelidate/validators'
import { computed, watch } from 'vue';

export default {
    name: 'ExtendedGreatestCommonDivisor',
    setup () {
        const mainStore = useMainStore();        
        const algo = computed(() => mainStore.algorithms.ExtendedGreatestCommonDivisor);
        const data = computed(() => algo.value.data);

        const rules = {
            number: { required },
            prime: { required  }
        };

        const v$ = useVuelidate(rules, data);

        watch(() => v$.value.$invalid, (value) => {
            algo.value.isValid = !value;
        });

        const isCurrentValid = computed(() => algo.value.isValid);  
        
        const getResultAsync = async () => {
            await mainStore.getResultAsync(data.value);
        };

        return {
            data,
            v$,
            isCurrentValid,
            getResultAsync
        }
    }
}
</script>

<style scoped>

</style>