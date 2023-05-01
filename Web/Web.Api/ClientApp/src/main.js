import { createApp } from 'vue'
import App from './App.vue'
import PrimeVue from 'primevue/config';
import router from './router';
import pinia from './store';
import ErrorMessages from './components/ErrorMessages.vue';
import Point from './components/Point.vue';

// Styles import.
import 'vue-loading-overlay/dist/css/index.css';
import './index.css'
import 'primevue/resources/themes/saga-blue/theme.css' // theme
import 'primevue/resources/primevue.min.css' // core css
import 'primeicons/primeicons.css' // icons


const app = createApp(App);

// Use PrimeVue.
app.use(PrimeVue);

// Use router.
app.use(router);

// Use pinia.
app.use(pinia);

// Error messages.
app.component('ErrorMessages', ErrorMessages);

// Point.
app.component('Point', Point);

app.mount('#app');
