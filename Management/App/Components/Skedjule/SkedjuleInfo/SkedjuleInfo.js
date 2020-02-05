
import moment from 'moment';
export default {
    name: 'SkedjuleInfo',

    created() {
        
        this.selectedPresness = this.$parent.selectedPresness;
        this.GetSkedjuleInfo();
    },
    data() {
        return {

            selectedPresness: [],
           
            
            SkedjuleInfo: [],
            

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
        GetSkedjuleInfo() {
            this.$blockUI.Start();
            this.$http.GetSkedjuleInfo(this.selectedPresness.id)
                .then(response => {

                    this.$blockUI.Stop();
                    this.SkedjuleInfo = response.data.skedjules;
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
