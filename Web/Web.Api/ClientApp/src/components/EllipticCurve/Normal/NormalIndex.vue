<template>
    <TabView>
        <TabPanel header="Sum">
            <Sum />
        </TabPanel>
        <TabPanel header="Alignson">
            <Alignson />
        </TabPanel>
    </TabView>
</template>

<script>
import Sum from './NormalSum.vue';
import Alignson from './NormalAlignson.vue';

export default {
    components: {
        Sum,
        Alignson
    },
    setup () {
        

        return {}
    }
}
</script>
