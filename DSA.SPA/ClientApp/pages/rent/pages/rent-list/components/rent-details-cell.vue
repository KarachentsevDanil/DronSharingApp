<template>
    <div class="text-muted text-size-small">
        <span>From: {{row.StartDate}} To: {{row.EndDate}} </span> <br>
        <span>Total Costs: {{row.TotalCosts}}</span>
    </div>
</template>

<script>
export default {
  props: ["row", "xprops"]
};
</script>