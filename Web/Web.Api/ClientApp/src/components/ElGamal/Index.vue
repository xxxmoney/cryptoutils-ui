<template>
    <TabView>
        <TabPanel header="Encryption">
            <ElGamalEncryption />
        </TabPanel>
        <TabPanel header="Decryption">
            <ElGamalDecryption />
        </TabPanel>
    </TabView>
</template>

<script>
import ElGamalEncryption from './ElGamalEncryption.vue';
import ElGamalDecryption from './ElGamalDecryption.vue';

export default {
    name: 'ElGamal',
    components: {
        ElGamalEncryption,
        ElGamalDecryption
    },
    setup () {

        return {}
    }
}
</script>
