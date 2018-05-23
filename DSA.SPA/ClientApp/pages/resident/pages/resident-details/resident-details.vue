<template>
    <div id="profile" class="content">
        <div id="profile-block" class="panel profile-cover bg-blue-400 has-bg-image position-relative no-border-radius">
            <profile-details :residentDetails="residentDetails"></profile-details>
        </div>
        <div class="tabbable">
            <ul class="nav nav-tabs nav-tabs-highlight">
                <li class="active"><a href="#home" data-toggle="tab" class="legitRipple">Home</a></li>
                <li><a href="#doctors" data-toggle="tab" class="legitRipple">Doctors</a></li>
                <li><a href="#appointments" data-toggle="tab" class="legitRipple">Appointments</a></li>
            </ul>

            <div class="tab-content">
                <div class="tab-pane active" id="home">
                    <div class="col-lg-3 col-md-3 col-sm-4 col-xs-12">
                        <patient-schedule :residentDetails="residentDetails"></patient-schedule>
                        <facility-details :residentDetails="residentDetails"></facility-details>
                    </div>
                    <div class="col-lg-6 col-md-6 col-sm-4 col-xs-12">
                        <span slot="no-more">
                            No More News
                        </span>
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-4 col-xs-12">
                        <birthday-notification :residentDetails="residentDetails"></birthday-notification>
                    </div>
                </div>
                <div class="tab-pane" id="doctors">
                </div>
                <div class="tab-pane" id="appointments">
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    import profileDetails from "./components/profile/profile";
    import birthdayNotification from "./components/timeline/birthday-notification";
    import facilityDetails from "./components/timeline/facility-details";
    import patientSchedule from "./components/timeline/patient-schedule";

    import * as residentService from "../../api/resident-service";

    export default {
        props: {
            id: {
                required: true
            }
        },
        components: {
            profileDetails: profileDetails,
            birthdayNotification: birthdayNotification,
            facilityDetails: facilityDetails,
            patientSchedule: patientSchedule
        },
        data() {
            return {
                residentDetails: {}
            };
        },
        methods: {
            async getResidentPage() {
                this.residentDetails = (await residentService.getResidentById(
                    this.id
                )).data.Data;
            }
        },
        watch: {
            $route(to, from) {
                this.getResidentPage();
            }
        },
        beforeMount() {
            this.getResidentPage();
        }
    };
</script>

<style>
    .profile-nav-bar {
        z-index: 1;
    }

    #profile-block {
        margin-bottom: 0px !important;
    }
</style>
