
import moment from 'moment';
import 'quill/dist/quill.core.css';
import 'quill/dist/quill.snow.css';
import 'quill/dist/quill.bubble.css';

import { quillEditor } from 'vue-quill-editor';

export default {
name: 'MassageDetals',    
created() {
    this.MassageDetals = this.$parent.SelectedMassages;

    this.GetReplayes(this.pageNo);
    this.MassageStatus = this.MassageDetals.sent;
    var item = this.MassageDetals.sent.filter(item => item.status === 7);
    var itemRead = this.MassageDetals.sent.filter(item => item.status === 3);
    var itemUnRead = this.MassageDetals.sent.filter(item => item.status === 4);
    this.countSeen = item.length;
    this.countRead = itemRead.length;
    this.countUnRead = itemUnRead.length;

    //this.GetMassages(this.pageNo);
},


filters: {
        moment: function (date) {
            if (date === null) {
                return "فارغ";
            }
            // return moment(date).format('MMMM Do YYYY, h:mm:ss a');
            return moment(date).format('h:mm A');
    },
      moments: function (date) {
        if (date === null) {
            return "فارغ";
        }
          return moment(date).format('MMMM Do YYYY');
       // return moment(date).format('h:mm A');
    }
    
},

    data() {
        return { 
            pageNo: 1,
            pageSize: 10,
            pages: 0,
            item: 0,
            MassageDetals:[],
            Replayes:[],
            Attachment:[],
            countSeen:0,
            content: "",
            ReplayBody:"",
            MassageStatus:0,
           countRead: 0,
            countUnRead:0,
            editorOption: {
                //debug: 'info',
                //placeholder: " ",
                //readOnly: true,
                //theme: 'snow',
                //modules: {
                //    toolbar: [
                //        ['bold', 'italic', 'underline'],
                //        ['code-block'],
                //        [{ 'color': [] }, { 'background': [] }],
                //        [{ 'list': 'ordered' }, { 'list': 'bullet' }],
                //        [{ 'direction': 'rtl' }],
                //        [{ 'align': [] }],

                //    ],
                //},
            },
        };
    },

methods: 
    {
        GetReplayes(pageNo) {
            this.pageNo = pageNo;
            if (this.pageNo === undefined) {
                this.pageNo = 1;
            }

            this.$blockUI.Start();
            this.$http.GetReplayes(this.pageNo, this.pageSize,this.$parent.SelectedMassages.conversationId)
                .then(response => {
                    this.$blockUI.Stop();
                    this.Replayes = response.data.replayesLists;
                    this.Attachment = response.data.attachments;
                    this.pages = response.data.count;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                    this.pages = 0;
                });
        },

        //1-AddToBockmarck
        //2-RemoveBockmarck
        //3-SetReadStatus
        //4-ChangeUnReadState
        //5-AddToArcive

   

        Back()
        {
            this.$parent.state=0;
        },

 
       
    }    

}
