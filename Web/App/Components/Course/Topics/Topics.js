import image from '../../../../Content/assets/img/docs/bg6.png';

export default {
    name: 'Topics',
    props:['lectures'],
    components: {

    },
    created() {
        
        console.log(this.lectures);
        this.data = this.lectures;
    },
    data() {
        return {
            selectedChapterIndex: null,
            highlightedLectureIndex: null,
            selectedLectureIndex: null,
            savedSelectedChapterIndex: null,
            hover: false,
            contentLink: '#Content',
            data: null
        };
    },
    methods: {
        setselectedChapterIndex(index) {
            if (this.selectedChapterIndex !== index) {
                this.selectedChapterIndex = index;
            } else if (this.selectedChapterIndex === index) {
             
                this.selectedChapterIndex = null;
            }
           
        }, sethighlightedLectureIndex(index) {
            
            this.highlightedLectureIndex = index;
           

        },
        setSelectedLectureIndex(index) {
            this.selectedLectureIndex = index;
            this.savedSelectedChapterIndex = this.selectedChapterIndex;
        },
        displayLecture(index, lectureIndex) {
            this.$emit('lecture', this.lectures.chapters[index].lectures[lectureIndex]);
        }
    }
}
