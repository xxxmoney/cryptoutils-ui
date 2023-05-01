<template>
    <div class="custom-container">
        <div>
            <span class="p-float-label">
                <InputNumber id="examinedNumber" :min="0" v-model="data.examinedNumber" class="w-full" />
                <label for="examinedNumber">Examined Number</label>
            </span>
            
            <ErrorMessages :v="v$" field="examinedNumber" />
        </div>

        <div>
            <ValidationChips v-model:values="data.numbers" validation_fail="Input should be number" :validation="isNumber" />
        </div>

        <Button :disabled="!isCurrentValid" label="Process" class="col-span-2" @click="getResultAsync()" />
    </div>
</template>

<script>
import { useMainStore } from '../../store/mainStore';
import { useVuelidate } from '@vuelidate/core';
import { required } from '@vuelidate/validators'
import { computed, watch } from 'vue';
import { isNumber } from '../../utils/validation';

export default {
    name: 'LehmanPeraltPrimality',
    setup () {
        const mainStore = useMainStore();        
        const algo = computed(() => mainStore.algorithms.LehmanPeraltPrimality);
        const data = computed(() => algo.value.data);

        const rules = {
            examinedNumber: { required },
            numbers: []
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
            isNumber,
            isCurrentValid,
            getResultAsync
        }
    }
}
</script>

<style scoped>

</style>