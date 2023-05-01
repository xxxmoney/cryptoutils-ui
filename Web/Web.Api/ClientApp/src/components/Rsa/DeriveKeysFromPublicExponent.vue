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
            <span class="p-float-label">
                <InputNumber id="q" :min="0" v-model="data.q" class="w-full" />
                <label for="q">q</label>
            </span>
            
            <ErrorMessages :v="v$" field="q" />
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
        const data = computed(() => algo.value.data.deriveKeysFromPublicExponent);

        const rules = {
            p: { required },
            q: { required },
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
