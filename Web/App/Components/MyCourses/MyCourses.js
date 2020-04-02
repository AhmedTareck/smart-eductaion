export default {
    name: 'MyCourses',
    components: {
     

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
        };
    },
    methods: {}
}