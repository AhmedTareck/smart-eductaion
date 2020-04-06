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

import Student from './Components/Student/Student.vue';
import AddStudent from './Components/Student/AddStudent/AddStudent.vue';

import Subjects from './Components/Subjects/Subjects.vue';
import AddSubjects from './Components/Subjects/AddSubjects/AddSubjects.vue';
import Users from './Components/Users/Users.vue';
import AddUsers from './Components/Users/AddUsers/AddUsers.vue';

import Years from './Components/Years/Years.vue';
import AddYears from './Components/Years/AddYears/AddYears.vue';
import Shapters from './Components/Shapters/Shapters.vue';
import AddShapters from './Components/Shapters/AddShapters/AddShapters.vue';
import AdsInfo from './Components/AdsInfo/AdsInfo.vue';
import AddAdsInfo from './Components/AdsInfo/AddAdsInfo/AddAdsInfo.vue';
import Lectures from './Components/Lectures/Lectures.vue';
import AddLectures from './Components/Lectures/AddLectures/AddLectures.vue';
import Excaming from './Components/Excaming/Excaming.vue';

import AddExaming from './Components/Excaming/AddExaming/AddExaming.vue';

import Events from './Components/Events/Events.vue';
import AddEvents from './Components/Events/AddEvents/AddEvents.vue';
import Parents from './Components/Parents/Parents.vue';
import AddParents from './Components/Parents/AddParents/AddParents.vue';

import Presness from './Components/Presness/Presness.vue';
import AddPresness from './Components/Presness/AddPresness/AddPresness.vue';

import Permissions from './Components/Permissions/Permissions.vue';
import Group from './Components/Group/Group.vue';

import Teacher from './Components/Teacher/Teacher.vue';
import AddTeacher from './Components/Teacher/AddTeacher/AddTeacher.vue';






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
        { path: '/Users', component: Users },
        { path: '/EditUsersProfile', component: EditUsersProfile },
        { path: '/Parents', component: Parents },
        { path: '/AddParents', component: AddParents },
        { path: '/Presness', component: Presness },
        { path: '/AddPresness', component: AddPresness },
        { path: '/ChangePassword', component: ChangePassword },  
        { path: '/Student', name: 'Student', component: Student },
        { path: '/AddStudent', name: 'Student', component: AddStudent },
        { path: '/Years', name: 'Years', component: Years },
        { path: '/AddUsers', name: 'AddUsers', component: AddUsers },
        { path: '/AddYears', name: 'AddYears', component: AddYears },
        { path: '/Subjects', name: 'Subjects', component: Subjects },
        { path: '/AddSubjects', name: 'Subjects', component: AddSubjects },
        { path: '/Shapters', name: 'Shapters', component: Shapters },
        { path: '/AddShapters', name: 'AddShapters', component: AddShapters },
        { path: '/AdsInfo', name: 'AdsInfo', component: AdsInfo },
        { path: '/AddAdsInfo', name: 'AddAdsInfo', component: AddAdsInfo },
        { path: '/Lectures', name: 'Lectures', component: Lectures },
        { path: '/AddLectures', name: 'AddLectures', component: AddLectures },
        { path: '/AddExaming', name: 'AddExaming', component: AddExaming },
        { path: '/Excaming', name: 'Excaming', component: Excaming },
        { path: '/Events', name: 'Events', component: Events },
        { path: '/AddEvents', name: 'AddEvents', component: AddEvents },
        { path: '/Permission', name: 'Permission', component: Permissions },
        { path: '/Group', name: 'Group', component: Group },
        { path: '/Teacher', name: 'Teacher', component: Teacher },
        { path: '/AddTeacher', name: 'AddTeacher', component: AddTeacher },




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
