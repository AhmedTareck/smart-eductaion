
import moment from 'moment';
export default {
    name: 'EditSkedjule',

    created() {
        this.selectedPresness = this.$parent.selectedPresness;
        this.GetPresnessInfo();
    },
    data() {
        return {
            selectedPresness: [],
            student: [],


            presness: {
                presnessId:'',
                lectureDate: '',
                edit: [],
            },

        };
    },

    filters: {
        moment: function (date) {
            if (date === null) {
                return 'فارغ';
            }
            // return moment(date).format('MMMM Do YYYY, h:mm:ss a');
            return moment(date).format('MMMM Do YYYY');
        }
    },


    methods: {

        GetPresnessInfo() {
            this.$blockUI.Start();
            this.$http.GetPresnessInfo(this.selectedPresness.id)
                .then(response => {

                    this.$blockUI.Stop();
                    this.student = response.data.student;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                });
        },

        back() {
            this.$parent.state = 0;
        },

        editPresness() {
            this.$confirm('سيؤدي ذلك إلى تعديل السجل  . استمر؟', 'تـحذير', {
                confirmButtonText: 'نـعم',
                cancelButtonText: 'لا',
                type: 'warning'
            }).then(() => {

                this.presness.edit = this.student;
                this.presness.lectureDate = this.selectedPresness.lectureDate;
                this.presness.presnessId = this.selectedPresness.id;



                this.$http.editPresness(this.presness)
                    .then(response => {
                        this.$message({
                            type: 'info',
                            message: response.data
                        });
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
            });
            
        }

    }
}
