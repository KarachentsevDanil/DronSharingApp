<template>
    <div class="profile-header">
        <div class="profile-cover-img" ></div>

        <a class="profile-thumb">
            <img :src="residentDetails.Photo ? residentDetails.Photo : 'https://upload.wikimedia.org/wikipedia/commons/1/1e/Default-avatar.jpg'" class="img-circle" alt="">
        </a>

        <div class="profile-details">
            <h1>{{residentDetails.FullName}}</h1>
            <p><span>Age: {{residentDetails.Age}}</span></p>
            <p><span>Birth Date: {{residentDetails.FormattedDate}}</span> (in {{residentDetails.DaysToBirthday}} days)</p>
        </div>

        <div class="profile-vitals">
            <ul class="list-inline vital">
                <li>
                    <a class="btn border-white text-white btn-flat btn-rounded btn-icon btn-xs valign-text-bottom legitRipple">
                        <i class="icon-pulse"></i>
                    </a>
                </li>
                <li class="text-left">
                    <div class="value">
                        {{ residentDetails.mainObservations ? residentDetails.mainObservations.heartRate : '75' }}
                    </div>
                    <div class="name">Heart rate</div>
                </li>
            </ul>
            <ul class="list-inline vital">
                <li>
                    <a href="#" class="btn border-white text-white btn-flat btn-rounded btn-icon btn-xs valign-text-bottom legitRipple">
                        <i class="icon-blood-pressure-control-tool"></i>
                    </a>
                </li>
                <li class="text-left">
                    <div class="value">
                        {{ residentDetails.mainObservations ? residentDetails.mainObservations.bloodPressure : '120 / 80' }}
                    </div>
                    <div class="name">Blood Pressure</div>
                </li>
            </ul>
            <ul class="list-inline vital">
                <li>
                    <a href="#" class="btn border-white text-white btn-flat btn-rounded btn-icon btn-xs valign-text-bottom legitRipple">
                        <i class="icon-temperature"></i>
                    </a>
                </li>
                <li class="text-left">
                    <div class="value">
                        {{ residentDetails.mainObservations ? residentDetails.mainObservations.temperature : '36.6' }}
                    </div>
                    <div class="name">Temperature</div>
                </li>
            </ul>
        </div>
    </div>
</template>

<script>
    export default {
        props: {
            residentDetails: {
                type: Object
            }
        }
    };
</script>