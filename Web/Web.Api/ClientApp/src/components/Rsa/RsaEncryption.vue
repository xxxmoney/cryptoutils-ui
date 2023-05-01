<template>
    <div class="custom-container">
        <div>
            <span class="p-float-label">
                <InputNumber id="m" :min="0" v-model="data.m" class="w-full" />
                <label for="m">m</label>
            </span>
            
            <ErrorMessages :v="v$" field="m" />
        </div>

        <div>
            <span class="p-float-label">
                <InputNumber id="n" :min="0" v-model="data.n" class="w-full" />
                <label for="n">n</label>
            </span>
            
            <ErrorMessages :v="v$" field="n" />
        </div>

        <div>
            <span class="p-float-label">
                <InputNumber id="e" :min="0" v-model="data.e" class="w-full" />
                <label for="e">e</label>
            </span>
            
            <ErrorMessages :v="v$" field="e" />
        </div>

    </div>
</template>

<script>
import { useMainStore } from '../../store/mainStore';
import { useVuelidate } from '@vuelidate/core';
import { required } from '@vuelidate/validators'
import { computed, watch } from 'vue';

export default {
    setup () {
        const mainStore = useMainStore();        
        const algo = computed(() => mainStore.algorithms.Rsa);
        const data = computed(() => algo.value.data.encryption);

        const rules = {
            m: { required },
            n: { required },
            e: { required },
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
