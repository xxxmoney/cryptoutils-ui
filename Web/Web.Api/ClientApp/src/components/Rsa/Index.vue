<template>
    <TabView>
        <TabPanel header="Encryption">
            <RsaEncryption />
        </TabPanel>
        <TabPanel header="Decryption">
            <RsaDecryption />
        </TabPanel>
        <TabPanel header="Derive private key from module">
            <DerivePrivateKeyFromModule />
        </TabPanel>
        <TabPanel header="Derive keys from public exponent">
            <DeriveKeysFromPublicExponent />            
        </TabPanel>
        <TabPanel header="Derive keys from private exponent">
            <DeriveKeysFromPrivateExponent />
        </TabPanel>        
    </TabView>
</template>

<script>
import RsaEncryption from './RsaEncryption.vue';
import RsaDecryption from './RsaDecryption.vue';
import DerivePrivateKeyFromModule from './DerivePrivateKeyFromModule.vue';
import DeriveKeysFromPublicExponent from './DeriveKeysFromPublicExponent.vue';
import DeriveKeysFromPrivateExponent from './DeriveKeysFromPrivateExponent.vue';

export default {
    name: 'Rsa',
    components: {
        RsaEncryption,
        RsaDecryption,
        DerivePrivateKeyFromModule,
        DeriveKeysFromPublicExponent,
        DeriveKeysFromPrivateExponent
    },
    setup () {

        return {}
    }
}
</script>
