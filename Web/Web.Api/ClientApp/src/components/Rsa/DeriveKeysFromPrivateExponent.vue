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
                <InputNumber id="d" :min="0" v-model="data.d" class="w-full" />
                <label for="d">d</label>
            </span>
            
            <ErrorMessages :v="v$" field="d" />
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
        const data = computed(() => algo.value.data.deriveKeysFromPrivateExponent);

        const rules = {
            p: { required },
            q: { required },
            d: { required },
        };

        const v$ = useVuelidate(rules, data);

        watch(() => v$.value.$invalid, (value) => {
            algo.value.isValid = !value;
        });

        const isCurrentValid = computed(() => algo.value.isValid);  
        
        const getResultAsync = async () => {
            await mainStore.getResultAsync({
                deriveKeysFromPrivateExponent: data.value
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
