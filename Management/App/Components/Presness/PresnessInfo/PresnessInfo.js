
import moment from 'moment';
export default {
    name: 'PresnessInfo',

    created() {
        
        this.selectedPresness = this.$parent.selectedPresness;
        this.GetPresnessInfo();
    },
    data() {
        return {

            state: 0,
            selectedPresness: [],
            student:[],

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
        }
    }
}
