    import moment from 'moment';

export default {
    name: 'home',
    components: {
      
    },
    created() {  
        this.GetMessageTypes(this.pageNo);
        this.GetCountInfo();
        setInterval(() => this.GetCountInfo(), 10000); 
    },
    data() {
        return {
            pageNo: 1,
            pageSize: 10,
            pages: 0,  
            MessageType: [],
            Massages:0,
            DeleteMassages:0,
            ArchiveMassages:0,
            MessageTypes:0,
        };
    },
    filters: {
            moment: function (date) {
                if (date === null) {
                    return "فارغ";
                }
                // return moment(date).format('MMMM Do YYYY, h:mm:ss a');
                return moment(date).format('MMMM Do YYYY');
            }
    },
    methods: {
        GetMessageTypes(pageNo) {
            this.pageNo = pageNo;
            if (this.pageNo === undefined) {
                this.pageNo = 1;
            }
            this.$blockUI.Start();
            this.$http.GetMessageTypes(this.pageNo, this.pageSize)
                .then(response => {
                    this.$blockUI.Stop();
                    this.MessageType = response.data.messageType;
                    this.pages = response.data.count;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                    this.pages = 0;
                });
        },

        GetCountInfo() {
            this.$http.GetCountInfo()
                .then(response => {
                    this.Massages = response.data.massages;
                    this.DeleteMassages = response.data.deleteMassages;
                    this.ArchiveMassages = response.data.archiveMassages;
                    this.MessageTypes = response.data.messageTypes;
                })
                .catch((err) => {
                });
        },
    }    
}






