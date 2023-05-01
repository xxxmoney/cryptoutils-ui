<template>
    <div class="custom-container">
        <div>
            <span class="p-float-label">
                <InputNumber id="curveA" :min="0" v-model="data.curveA" class="w-full" />
                <label for="curveA">Curve A</label>
            </span>

            <ErrorMessages :v="v$" field="curveA" />
        </div>

        <div>
            <span class="p-float-label">
                <InputNumber id="curveB" :min="0" v-model="data.curveB" class="w-full" />
                <label for="curveB">Curve B</label>
            </span>

            <ErrorMessages :v="v$" field="curveB" />
        </div>

        <div class="col-span-2">
            <span class="p-float-label">
                <InputNumber id="curvePrime" :min="0" v-model="data.curvePrime" class="w-full" />
                <label for="curvePrime">Curve Prime</label>
            </span>

            <ErrorMessages :v="v$" field="curvePrime" />
        </div>

        <Point :v="v$" field="point" labelX="Point X" labelY="Point Y" v-model:x="data.point.x" v-model:y="data.point.y" class="col-span-2" />
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
        const data = computed(() => algo.value.data.normal.alignson);

        const rules = {
            curveA: { required },
            curveB: { required },
            curvePrime: { required },
            point: { 
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

