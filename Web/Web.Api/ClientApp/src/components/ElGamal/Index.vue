<template>
    <TabView>
        <TabPanel header="Encryption">
            <Encryption />
        </TabPanel>
        <TabPanel header="Decryption">
            <Decryption />
        </TabPanel>
    </TabView>
</template>

<script>
import Encryption from './Encryption.vue';
import Decryption from './Decryption.vue';

export default {
    name: 'ElGamal',
    components: {
        Encryption,
        Decryption
    },
    setup () {

        return {}
    }
}
</script>
