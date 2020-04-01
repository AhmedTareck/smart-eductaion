import Topics from './Topics/Topics.vue';
import Content from './Content/Content.vue';

export default {
    name: 'Course',
    components: {
        'Topics': Topics,
        'Content': Content,
    },
    created() {
    },
    data() {
        return {
            selectedLecture: null
        };
    },
    methods: {
        setLecture(lecture) {
            this.selectedLecture = lecture;
        }
    }
}