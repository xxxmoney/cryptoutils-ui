<template>
    <div class="custom-container">
        <div>
            <span class="p-float-label">
                <InputText inputid="curveA_G" v-model="data.curveA_G" class="w-full" />
                <label for="curveA_G">Curve A G</label>
            </span>

            <ErrorMessages :v="v$" field="curveA_G" />
        </div>

        <div>
            <span class="p-float-label">
                <InputText inputid="curveB_G" v-model="data.curveB_G" class="w-full" />
                <label for="curveB_G">Curve B G</label>
            </span>

            <ErrorMessages :v="v$" field="curveB_G" />
        </div>

        <div>
            <span class="p-float-label">
                <InputText inputid="polynomialBinary" v-model="data.polynomialBinary" class="w-full" />
                <label for="polynomialBinary">Polynomial Binary</label>
            </span>

            <ErrorMessages :v="v$" field="polynomialBinary" />
        </div>

        <div>
            <span class="p-float-label">
                <InputNumber inputid="n" :min="0" v-model="data.n" class="w-full" />
                <label for="n">N</label>
            </span>

            <ErrorMessages :v="v$" field="n" />
        </div>

        <div class="col-span-2">
            <span class="p-float-label">
                <InputText inputid="irreduciblePolynomialBinary" v-model="data.irreduciblePolynomialBinary" class="w-full" />
                <label for="irreduciblePolynomialBinary">Irreducible Polynomial Binary</label>
            </span>

            <ErrorMessages :v="v$" field="irreduciblePolynomialBinary" />
        </div>        

        <CustomPoint :v="v$" field="firstPoint" labelX="First Point X" labelY="First Point Y" v-model:x="data.firstPoint.x" v-model:y="data.firstPoint.y" class="col-span-2" />
        <CustomPoint :v="v$" field="secondPoint" labelX="Second Point X" labelY="Second Point Y" v-model:x="data.secondPoint.x" v-model:y="data.secondPoint.y" class="col-span-2" /> 
    </div>
</template>

<script>
import { useMainStore } from '@/store/mainStore';
import { useVuelidate } from '@vuelidate/core';
import { required } from '@vuelidate/validators'
import { computed, watch } from 'vue';

export default {
    setup () {
        const mainStore = useMainStore();        
        const algo = computed(() => mainStore.algorithms.EllipticCurve);
        const data = computed(() => algo.value.data.advanced.sum);

        const rules = {
            curveA_G: { required },
            curveB_G: { required },
            polynomialBinary: { required },
            irreduciblePolynomialBinary: { required },
            n: { required },
            firstPoint: {
                x: { required },
                y: { required }            
            },
            secondPoint: {
                x: { required },
                y: { required }            
            }
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
