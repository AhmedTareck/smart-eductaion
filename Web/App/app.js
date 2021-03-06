import Vue from 'vue';
import VueI18n from 'vue-i18n'
import VueRouter from 'vue-router';
import ElementUI from 'element-ui';
import Vuetify from 'vuetify'
import locale from 'element-ui/lib/locale/lang/en'
import BlockUIService from './Shared/BlockUIService.js';
import Layout from './Components/Layout/Layout.vue';
import Login from './Components/Login/Login.vue';
import SignUp from './Components/SignUp/SignUp.vue';
import Home from './Components/Home/Home.vue';
import Course from './Components/Course/Course.vue';
import MyCourses from './Components/MyCourses/MyCourses.vue';
import Messages from './Components/Messages/Messages.vue';
import StudentProfile from './Components/StudentProfile/StudentProfile.vue';
import ContactUs from './Components/ContactUs/ContactUs.vue';
/*import Students from './Components/Students/Students.vue';
import Companies from './Components/Companies/Companies.vue';
import Packages from './Components/Packages/Packages.vue';
import SuperPackages from './Components/Packages/SuperPackages/SuperPackages.vue';
import SubPackages from './Components/Packages/SubPackages/SubPackages.vue';
import SubPackagesMain from './Components/SubPackages/SubPackages.vue';
import Courses from './Components/Packages/Courses/Courses.vue';
import CoursesMain from './Components/Courses/Courses.vue';
import SubPackageCourses from './Components/Packages/SubPackages/Courses/Courses.vue'
import CourseFiles from './Components/CourseFiles/CourseFiles.vue'; */

import DataService from './Shared/DataService';
import messages from './i18n';



Vue.use(Vuetify)
Vue.use(VueI18n);
Vue.use(VueRouter);
Vue.use(ElementUI, { locale });

Vue.config.productionTip = false;

Vue.prototype.$http = DataService;
Vue.prototype.$blockUI = BlockUIService;


export const eventBus = new Vue();

const i18n = new VueI18n({
    locale: 'ar', // set locale
    messages, // set locale messages
})

const router = new VueRouter({
    mode: 'history',
    base: __dirname,
    linkActiveClass: 'active',
    routes: [
        { path: '/', component: Home },
        { path: '/Login', component: Login },
        { path: '/SignUp', component: SignUp },
        { path: '/Course', component: Course },
        { path: '/MyCourses', component: MyCourses },
        { path: '/Messages', component: Messages },
        { path: '/StudentProfile', component: StudentProfile },
        { path: '/ContactUs', component: ContactUs }
    ]

});

Vue.filter('toUpperCase', function (value) {
    if (!value) return '';
    return value.toUpperCase();
});

new Vue({
    i18n,
    router,
    render: h => {
        return h(Layout);
    }
}).$mount('#app');



