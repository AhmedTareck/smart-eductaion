export default {
    name: 'MyCourses',
    components: {
     

    },
    created() {
        var loginDetails = localStorage.getItem('currentUser');
        if (loginDetails !== null && loginDetails !== "null") {
            this.loginDetails = JSON.parse(loginDetails);
            this.GetMySubjects(this.pageNo);
        } else {
            window.location.href = '/Login';
        }
    },
    data() {
        return {
            loginDetails: null,
            pageNo: 1,
            pageSize: 3,
            pages: 0, 
            Subjects:[],
        };
    },
    methods: {
        //GetMySubjects
        GetMySubjects(pageNo) {
            this.pageNo = pageNo;
            if (this.pageNo === undefined) {
                this.pageNo = 1;
            }
            this.$blockUI.Start();
            this.$http.GetMySubjects(this.pageNo, this.pageSize)
                .then(response => {
                    this.$blockUI.Stop();
                    this.Subjects = response.data.subjects;
                    this.pages = response.data.count;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                    this.pages = 0;
                });
        },

    }
}