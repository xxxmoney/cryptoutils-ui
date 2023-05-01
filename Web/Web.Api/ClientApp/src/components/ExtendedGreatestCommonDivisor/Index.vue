<template>
    <div class="grid grid-cols-2 gap-2 pt-5">
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

        return {
            data,
            v$
        }
    }
}
</script>

<style scoped>

</style>