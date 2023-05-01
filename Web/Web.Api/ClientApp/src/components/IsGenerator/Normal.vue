<template>
    <div class="custom-container">
        <div>
            <span class="p-float-label">
                <InputNumber id="p" :min="0" v-model="data.p" class="w-full" />
                <label for="p">p</label>
            </span>
            
            <ErrorMessages :v="v$" field="p" />
        </div>

        <div>
            <ValidationChips v-model:values="data.numbers" validation_fail="Input should be number" :validation="isNumber" />
        </div>

    </div>
</template>

<script>
import { useMainStore } from '../../store/mainStore';
import { useVuelidate } from '@vuelidate/core';
import { required } from '@vuelidate/validators'
import { computed, watch } from 'vue';
import { isNumber } from '../../utils/validation';

export default {
    setup () {
        const mainStore = useMainStore();        
        const algo = computed(() => mainStore.algorithms.IsGenerator);
        const data = computed(() => algo.value.data.normal);

        const rules = {
            p: { required },
            numbers: []
        };

        const v$ = useVuelidate(rules, data);

        watch(() => v$.value.$invalid, (value) => {
            algo.value.isValid = !value;
        });        

        return {
            data,
            v$,
            isNumber
        }
    }
}
</script>
