<template>
    <div class="custom-container">
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

        <Button :disabled="!isCurrentValid" label="Process" class="col-span-2" @click="getResultAsync()" />
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
        const data = computed(() => algo.value.data.derivePrivateKeyFromModule);

        const rules = {
            n: { required },
            e: { required },
        };

        const v$ = useVuelidate(rules, data);

        watch(() => v$.value.$invalid, (value) => {
            algo.value.isValid = !value;
        });

        const isCurrentValid = computed(() => algo.value.isValid);  
        
        const getResultAsync = async () => {
            await mainStore.getResultAsync({
                derivePrivateKeyFromModule: data.value
            });
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
