import Vue from 'vue';
import VueI18n from 'vue-i18n';
import VueRouter from 'vue-router';
import ElementUI from 'element-ui';
import Vuetify from 'vuetify';
import locale from 'element-ui/lib/locale/lang/en';
import BlockUIService from './Shared/BlockUIService.js';
import Layout from './Components/Layout/Layout.vue';
import Home from './Components/Home/Home.vue';

import EditUsersProfile from './Components/Users/EditUsersProfile/EditUsersProfile.vue';
import ChangePassword from './Components/Users/ChangePassword/ChangePassword.vue';
import Subscribes from './Components/Subscribes/Subscribes.vue';

import Student from './Components/Student/Student.vue';
import AddStudent from './Components/Student/AddStudent/AddStudent.vue';
import Presness from './Components/Presness/Presness.vue';
import AddPresness from './Components/Presness/AddPresness/AddPresness.vue';
import HomeWorcks from './Components/HomeWorcks/HomeWorcks.vue';
import AddHomeWorck from './Components/HomeWorcks/AddHomeWorck/AddHomeWorck.vue';
import Exam from './Components/Exam/Exam.vue';
import AddExam from './Components/Exam/AddExam/AddExam.vue';
import Grids from './Components/Exam/Grids/Grids.vue';
import Skedjule from './Components/Skedjule/Skedjule.vue';
import AddSkedjule from './Components/Skedjule/AddSkedjule/AddSkedjule.vue';
import Years from './Components/Years/Years.vue';
import Subjects from './Components/Subjects/Subjects.vue';
import Users from './Components/Users/Users.vue';
import Parents from './Components/Parents/Parents.vue';
import Degrees from './Components/Degrees/Degrees.vue';
import AddParents from './Components/Parents/AddParents/AddParents.vue';
import AddUsers from './Components/Users/AddUsers/AddUsers.vue';
import AddDegrees from './Components/Degrees/AddDegrees/AddDegrees.vue';
import Notification from './Components/Notification/Notification.vue';
import AddNotification from './Components/Notification/AddNotification/AddNotification.vue';
import AddNotificationParent from './Components/Notification/AddNotificationParent/AddNotificationParent.vue';





import DataService from './Shared/DataService';
import messages from './i18n';



Vue.use(Vuetify);
Vue.use(VueI18n);
Vue.use(VueRouter);
Vue.use(ElementUI,{ locale });

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
        { path: '/Subscribes', component: Subscribes }, 
        { path: '/Users', component: Users },
        { path: '/EditUsersProfile', component: EditUsersProfile },
        { path: '/ChangePassword', component: ChangePassword },  

        { path: '/Student', name: 'Student', component: Student },
        { path: '/AddStudent', name: 'Student', component: AddStudent },
        { path: '/Presness', name: 'Presness', component: Presness },
        { path: '/AddPresness', name: 'AddPresness', component: AddPresness },
        { path: '/HomeWorcks', name: 'HomeWorcks', component: HomeWorcks },
        { path: '/AddHomeWorck', name: 'AddHomeWorck', component: AddHomeWorck },
        { path: '/Exam', name: 'Exam', component: Exam },
        { path: '/AddExam', name: 'AddExam', component: AddExam },
        { path: '/Grids', name: 'Grids', component: Grids },
        { path: '/Skedjule', name: 'Skedjule', component: Skedjule },
        { path: '/AddSkedjule', name: 'AddSkedjule', component: AddSkedjule },
        { path: '/Years', name: 'Years', component: Years },
        { path: '/Subjects', name: 'Subjects', component: Subjects },
        { path: '/Degrees', name: 'Degrees', component: Degrees },
        { path: '/AddUsers', name: 'AddUsers', component: AddUsers },
        { path: '/Parents', name: 'Parents', component: Parents },
        { path: '/AddParents', name: 'AddParents', component: AddParents },
        { path: '/AddDegrees', name: 'AddDegrees', component: AddDegrees },
        { path: '/AddNotification', name: 'AddNotification', component: AddNotification },
        { path: '/Notification', name: 'Notification', component: Notification },
        { path: '/AddNotificationParent', name: 'AddNotificationParent', component: AddNotificationParent }

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
