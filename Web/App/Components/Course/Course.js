import Topics from './Topics/Topics.vue';
import Content from './Content/Content.vue';

export default {
    name: 'Course',
    components: {
        'Topics': Topics,
        'Content': Content
    },
    created() {

        var loginDetails = localStorage.getItem('currentUser');
        if (loginDetails !== null && loginDetails !== "null") {
            this.loginDetails = JSON.parse(loginDetails);
            
        } else {
            window.location.href = '/Login';
        }

        this.GetLectures();
        
    },
    data() {
        return {
            loginDetails:null,
            selectedLecture: null,
            lectures: null,
            subjectId: null
        };
    },
    methods: {
        setLecture(lecture) {
            this.selectedLecture = lecture;
        },
        GetLectures() {
            this.subjectId = this.$route.query.subject;
            
            if (!this.subjectId) {
                 window.location.href = '/MyCourses';
                return;
            }
            let $blockUI = this.$loading({
                fullscreen: true,
                text: 'loading ...'
            });
            this.$http.GetLectures(this.subjectId).then(response => {
                $blockUI.close();
                this.lectures = response.data[0];
            }).catch(error => {
                $blockUI.close();
                this.$message({
                    type: 'error',
                    dangerouslyUseHTMLString: true,
                    duration: 5000,
                    message: '<strong>' + error.response.data + '</strong>'
                });

                if (error.response.status === 400) {
                    this.$message({
                        type: 'warning',
                        dangerouslyUseHTMLString: true,
                        duration: 5000,
                        message: '<strong>' + error.response.data + '</strong>'
                    });

                } else if (error.response.status === 404) {
                    this.$message({
                        type: 'warning',
                        dangerouslyUseHTMLString: true,
                        duration: 5000,
                        message: '<strong>' + error.response.data + '</strong>'
                    });

                } else {
                    console.log(error.response);
                }
                window.location.href = '/MyCourses';
            });

        }
    },
}