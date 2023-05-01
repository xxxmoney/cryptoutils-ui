<template>
    <TabView>
        <TabPanel header="Sum">
            <Sum />
        </TabPanel>
        <TabPanel header="Multiply">
            <Multiply />
        </TabPanel>
        <TabPanel header="Alignson">
            <Alignson />
        </TabPanel>
    </TabView>
</template>

<script>
import Sum from './AdvancedSum.vue';
import Multiply from './AdvancedMultiply.vue';
import Alignson from './AdvancedAlignson.vue';

export default {
    components: {
        Sum,
        Multiply,
        Alignson
    },
    setup () {
        

        return {}
    }
}
</script>
