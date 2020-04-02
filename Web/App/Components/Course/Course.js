import Topics from './Topics/Topics.vue';
import Content from './Content/Content.vue';

export default {
    name: 'Course',
    components: {
        'Topics': Topics,
        'Content': Content,
    },
    created() {

        var loginDetails = localStorage.getItem('currentUser');
        this.loginDetails = JSON.parse(loginDetails);
        if (loginDetails !== null) {
            this.loginDetails = JSON.parse(loginDetails);
        } else {
            window.location.href = '/Login';
        }
    },
    data() {
        return {
            loginDetails:null,
            selectedLecture: null
        };
    },
    methods: {
        setLecture(lecture) {
            this.selectedLecture = lecture;
        }
    }
}