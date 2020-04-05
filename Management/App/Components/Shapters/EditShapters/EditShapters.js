import moment from 'moment';
export default {
    name: 'EditShapters',
    
    created() {
        this.getyearName();
        this.form.id = this.$parent.selectedItem.id;
        this.form.name = this.$parent.selectedItem.name;
        this.form.SubjectId = this.$parent.selectedItem.subjectId;
        this.form.ShapterNumber = this.$parent.selectedItem.number;
        this.form.EventId = this.$parent.selectedItem.eventId;
        this.form.yearId = this.$parent.selectedItem.yearId;
        
        //this.getSubject()();
        //this.getEventName()();
        //this.form.id = this.$parent.selectedItem.id;
        //this.form.name = this.$parent.selectedItem.name;
        //this.form.SubjectId = this.$parent.selectedItem.subjectId;
        //this.form.ShapterNumber = this.$parent.selectedItem.shapterNumber;
        //this.form.EventId = this.$parent.selectedItem.eventId;
        //this.form.yearId = this.$parent.selectedItem.yearId;
    },
    components: {
    },
    data() {
        return {
            form: {
                
                id: '',
                name: '',
                SubjectId: '',
                ShapterNumber: '',
                EventId: '',
                yearId:'',
            },

            year: [],

            SubjectName: [],

            EventName: [],
        };
    },

    filters: {
        moment: function (date) {
            if (date === null) {
                return 'فارغ';
            }
            return moment(date).format('MMMM Do YYYY');
        }
    },


    methods: {
        back() {
            this.$parent.state = 0;
        },

        getyearName() {

            this.$blockUI.Start();
            this.$http.getyearName()
                .then(response => {

                    this.$blockUI.Stop();
                    this.year = response.data.years;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                });
        },

        getSubject() {
            //this.SubjectName = [];
            //this.form.SubjectId= '';
            //this.getShpater();
            this.$blockUI.Start();
            this.$http.getSubject(this.form.yearId)

                .then(response => {

                    this.$blockUI.Stop();
                    this.SubjectName = response.data.subject;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                });
        },

        getEventName() {
            //this.SubjectName = [];
            //this.form.SubjectId = '';
            //this.getShpater();
            this.$blockUI.Start();
            this.$http.getEventName(this.form.SubjectId)

                .then(response => {

                    this.$blockUI.Stop();
                    this.EventName = response.data.eventinfo;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                });
        },


        editShpter() {
            this.$blockUI.Start();
            this.$http.editShpter(this.form)
                .then(response => {
                    //this.$parent.state = 0;
                    this.$message({
                        type: 'info',
                        message: response.data
                    });
                    this.$parent.getShpater();
                    this.$parent.state = 0;
                    this.$blockUI.Stop();
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    this.$message({
                        type: 'error',
                        message: err.response.data
                    });
                });
        }
    }    
}
