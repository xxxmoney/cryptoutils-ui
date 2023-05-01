<template>
    <div class="custom-container">
        <div class="col-span-2">
            <span class="p-float-label">
                <InputText id="irreduciblePolynomialBinary" v-model="data.irreduciblePolynomialBinary" class="w-full" />
                <label for="irreduciblePolynomialBinary">Irreducible Polynomial Binary</label>
            </span>
            
            <ErrorMessages :v="v$" field="irreduciblePolynomialBinary" />
        </div>

        <div class="col-span-2">
            <span class="p-float-label">
                <InputNumber id="n" :min="0" v-model="data.n" class="w-full" />
                <label for="n">n</label>
            </span>
            
            <ErrorMessages :v="v$" field="n" />
        </div>        

        <div>
            <span class="">
                <label class=" text-xs" for="polynomialsBinary">Polynomials Binary</label>
                <ValidationChips id="polynomialsBinary" v-model:values="data.polynomialsBinary" validation_fail="Input should be number" :validation="isBinary" />
            </span>
        </div>

    </div>
</template>

<script>
import { useMainStore } from '../../store/mainStore';
import { useVuelidate } from '@vuelidate/core';
import { required } from '@vuelidate/validators'
import { computed, watch } from 'vue';
import { isBinary, isBinaryValidation } from '../../utils/validation';

export default {
    setup () {
        const mainStore = useMainStore();        
        const algo = computed(() => mainStore.algorithms.IsGenerator);
        const data = computed(() => algo.value.data.advanced);

        const rules = {
            irreduciblePolynomialBinary: { isBinaryValidation },
            n: { required },
            polynomialsBinary: []
        };

        const v$ = useVuelidate(rules, data);

        watch(() => v$.value.$invalid, (value) => {
            algo.value.isValid = !value;
        });       

        return {
            data,
            v$,
            isBinary
        }
    }
}
</script>
