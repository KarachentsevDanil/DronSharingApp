<template>
    <div>
        <div class="panel">
            <div class="panel-body text-center">
                <div class="icon-object border-success text-success">
                    <i class="far fa-calendar-alt"></i>
                </div>
                <h5 class="text-semibold">Schedule an Appointment</h5>
                <a href="#" class="btn bg-success-400 legitRipple" data-toggle="modal" data-target="#addNewAppointment">Select Date</a>

            </div>

        </div>
    </div>
</template>

<script>
export default {
  data() {
    return {
      dialog: false,
      e1: 1,
      editable: false,
      date: "2018-03-08",
      time: "12:00",
      visitType: ""
    };
  },
  props: {
    residentDetails: {
      type: Object
    }
  }
};
</script>

<style scoped>
.event-details-block {
  margin-bottom: 20px;
  height: 220px;
  border-width: 0;
  color: #333;
  box-shadow: 0 1px 3px rgba(0, 0, 0, 0.12), 0 1px 2px rgba(0, 0, 0, 0.24);
  background: #fff;
}

.event-details-block .icon-wrap {
  text-align: center;
}

.event-details-block .text-wrap {
  text-align: center;
  margin-top: 20px;
  font-weight: 800;
}

.event-details-block i {
  font-size: 32px;
  padding: 20px 22px;
  color: #4caf50;
  border: 3px solid #4caf50;
  border-radius: 50%;
  left: 50%;
}

div.dialog__container {
  width: 100%;
}

.schedule-button {
  width: 250px;
}

.schedule-btn-group {
  display: flex;
  flex-direction: column;
  align-items: center;
}

.date-pick {
  height: 392px !important;
}

#schedule {
  margin-top: 20px;
  margin-left: -60px;
  left: 50%;
  width: 120px;
  background-color: #66bb6a;
  border-color: #66bb6a;
  color: #fff;
  font-weight: 500;
  font-size: 13px;
}
</style>
