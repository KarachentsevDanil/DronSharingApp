<template>
    <div class="sidebar sidebar-main">
        <div class="sidebar-content">
            <!-- User menu -->
            <div class="sidebar-user-material">
                <div class="category-content">
                    <div class="sidebar-user-material-content">
                        <a class="btn bg-teal-400 btn-rounded btn-icon btn-xs legitRipple">
                            <span>
                                {{getNameIncon}}
                            </span>
                        </a>
                        <h6 class="user-name">{{getUsername.FullName}}</h6>
                        <span class="text-size-small">{{getUsername.Email}}</span>
                    </div>

                    <div class="sidebar-user-material-menu">
                        <a href="#user-nav" data-toggle="collapse" class="legitRipple"><span>My Account</span> <i class="caret"></i></a>
                    </div>
                </div>

                <div class="navigation-wrapper collapse" id="user-nav">
                    <ul class="navigation">
                        <li>
                            <router-link active-class="active" class="legitRipple" :to="'/user-profile'">
                                <i class="icon-user6"></i>
                                <span>My Profile</span>
                            </router-link>
                        </li>
                        <!-- <li>
                            <router-link active-class="active" class="legitRipple" :to="'/messages'">
                                <i class="icon-bubbles5"></i>
                                <span>
                                    <span class="badge bg-teal-400 pull-right">58</span> Messages
                                </span>
                            </router-link>
                        </li> -->
                        <li class="divider"></li>
                        <li>
                            <a class="legitRipple" v-on:click="logout">
                                <i class="icon-exit"></i>
                                <span>Logout</span>
                            </a>
                        </li>
                    </ul>
                </div>
            </div>
            <div class="sidebar-category sidebar-category-visible">
                <div class="category-content no-padding">
                    <ul class="navigation navigation-main navigation-accordion">
                        <li class="navigation-header"><span>Air Taxi Sharing Portal</span> <i class="icon-menu" title="" data-original-title="Main pages"></i></li>
                        <li :class="{'active': isPanelActive(item)}" v-for="item in getNavbarItems" :key="item.title">
                            <router-link active-class="active" :class="{'legitRipple':true,'has-ul':item.children.length}" :to="item.url">
                                <i :class="[item.icon]"></i>
                                <span>
                                    {{item.title}}
                                </span>
                            </router-link>
                            <ul v-if="item.children.length">
                                <li v-for="child in item.children" :key="child.title">
                                    <router-link active-class="active" class="legitRipple" :to="child.url">
                                        {{child.title}}
                                    </router-link>
                                </li>
                            </ul>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import * as authGetters from "../auth/store/types/getter-types";
import * as authActions from "../auth/store/types/action-types";
import * as authResources from "../auth/store/resources";
import { mapGetters } from "vuex";

import * as mainStoreGetters from "../../store/types/action-types";

export default {
  data() {
    return {
      adminTaxiItems: [
        {
          title: "Air Taxi",
          icon: "icon-users2",
          url: "",
          children: [
            {
              title: "Company List",
              url: "/companies"
            },
            {
              title: "Type List",
              url: "/taxi-types"
            },
            {
              title: "Model List",
              url: "/taxi-models"
            },
            {
              title: "Taxies List",
              url: "/taxies"
            }
          ]
        },
        {
          title: "Rents",
          icon: "icon-cog3",
          url: "",
          children: [
            {
              title: "Rents List",
              url: "/rent-list"
            }
          ]
        }
      ],
      userTaxiItems: [
        {
          title: "Air Taxi",
          icon: "icon-users2",
          url: "",
          children: [
            {
              title: "Model List",
              url: "/taxi-models"
            },
            {
              title: "My Taxy List",
              url: "/taxies"
            }
          ]
        },
        {
          title: "Rents",
          icon: "icon-cog3",
          url: "",
          children: [
            {
              title: "Rent Taxi",
              url: "/rent-taxi"
            },
            {
              title: "My Rents List",
              url: "/rent-list"
            }
          ]
        }
      ]
    };
  },
  computed: {
    ...mapGetters({
      getUsername: authResources.AUTH_STORE_NAMESPACE.concat(
        authGetters.GET_USER_GETTER
      )
    }),
    getNameIncon() {
      let data = this.getUsername.FullName;
      let icon = data.split(" ");

      if (icon.length > 1) {
        return icon[0][0] + icon[1][0];
      }

      return icon[0][0] + icon[0][1];
    },
    getNavbarItems() {
      let role = this.getUsername.Role;
    
      return role == "User" ? this.userTaxiItems : this.adminTaxiItems;
    }
  },
  methods: {
    isPanelActive(item) {
      let isActive = false;

      isActive = item.url == this.$route.path;

      if (isActive) {
        return true;
      }

      isActive = item.children.some(t => t.url == this.$route.path);

      return isActive;
    },
    logout() {
      this.$store.dispatch(
        authResources.AUTH_STORE_NAMESPACE.concat(authActions.LOGOUT_ACTION)
      );

      this.$router.push("/login");
    }
  }
  // props: {
  //     user: {
  //         type: Object
  //     }
  // }
};
</script>

<style>
.user-name {
  font-size: 15px;
}
</style>