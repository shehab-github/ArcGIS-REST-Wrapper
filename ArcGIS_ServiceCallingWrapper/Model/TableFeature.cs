using ArcGIS_ServiceCallingWrapper.Helpers;
using Newtonsoft.Json;
using System;

namespace ArcGIS_ServiceCallingWrapper.Model
{
    public class TableFeature
    {
        //public NaProjectDetails Attributes { get; set; }
        public TableAttributes Attributes { get; set; }
    }

    public class TableAttributes
    {
        [IsNullAllowed(false)]
        [JsonProperty("project_id")]
        public string ProjectId { get; set; }

        [IsNullAllowed(false)]
        [JsonProperty("entity_id")]
        public int? EntityId { get; set; }

        [IsNullAllowed(false)]
        [JsonProperty("project_category_id")]
        public int? CategoryId { get; set; }

        [IsNullAllowed(false)]
        [JsonProperty("project_phase_id")]
        public int? PhaseId { get; set; }

        [IsNullAllowed(false)]
        [JsonProperty("project_status_id")]
        public int? StatusId { get; set; }

        [IsNullAllowed(false)]
        [JsonProperty("pm_nationality_id")]
        public int? PmNationalityId { get; set; }

        [JsonProperty("dof_no")]
        public string DofNo { get; set; }

        [MaxLength(300)]
        [JsonProperty("project_name")]
        public string ProjectName { get; set; }

        [MaxLength(500)]
        [JsonProperty("project_description")]
        public string ProjectDescription { get; set; }

        [MaxLength(300)]
        [JsonProperty("project_elements")]
        public string ProjectElements { get; set; }

        [JsonProperty("approved_budget")]
        public decimal? ApprovedBudget { get; set; }

        [JsonProperty("original_contract_value_design")]
        public decimal? OriginalContractValueDesign { get; set; }

        [JsonProperty("original_contract_value_super")]
        public decimal? OriginalContractValueSupervision { get; set; }

        [JsonProperty("original_contract_value_contcr")]
        public decimal? OriginalContractValueContractor { get; set; }

        [JsonProperty("cost_sq_m")]
        public decimal? CostSqm { get; set; }

        [JsonProperty("cost_plots")]
        public decimal? CostPlots { get; set; }

        [JsonProperty("allocated_cur_year_budget")]
        public decimal? AllocatedCurYearBudget { get; set; }

        [JsonProperty("planned_one_budget")]
        public decimal? PlannedOneBudget { get; set; }

        [JsonProperty("planned_two_budget")]
        public decimal? PlannedTwoBudget { get; set; }

        [JsonProperty("planned_three_budget")]
        public decimal? PlannedThreeBudget { get; set; }

        [JsonProperty("planned_four_budget")]
        public decimal? PlannedFourBudget { get; set; }

        [JsonProperty("planned_five_budget")]
        public decimal? PlannedFiveBudget { get; set; }

        [JsonProperty("planned_budget_later_five")]
        public decimal? PlannedBudgetLaterFive { get; set; }

        [JsonProperty("variation_order_no")]
        public decimal? VariationOrderNo { get; set; }

        [JsonProperty("variation_order_total")]
        public decimal? VariationOrderTotal { get; set; }

        [JsonProperty("variation_order_alloc_bud_totl")]
        public decimal? VariationOrderAllocateBudgetTotal { get; set; }

        [JsonProperty("resolution_date")]
        public DateTime? ResolutionDate { get; set; }

        [JsonProperty("resolution_recvd_date")]
        public DateTime? ResolutionRecvdDate { get; set; }

        [JsonProperty("forecast_q1_cur_year")]
        public decimal? ForecastQ1CurYear { get; set; }

        [JsonProperty("expenditures_q1_cur_year")]
        public decimal? ExpendituresQ1CurYear { get; set; }

        [MaxLength(500)]
        [JsonProperty("achieved_milestones")]
        public string AchievedMilestones { get; set; }

        [JsonProperty("forecast_q2_cur_year")]
        public decimal? ForecastQ2CurYear { get; set; }

        [JsonProperty("expenditures_q2_cur_year")]
        public decimal? ExpendituresQ2CurYear { get; set; }

        [JsonProperty("forecast_q3_cur_year")]
        public decimal? ForecastQ3CurYear { get; set; }

        [JsonProperty("expenditures_q3_cur_year")]
        public decimal? ExpendituresQ3CurYear { get; set; }

        [JsonProperty("forecast_q4_cur_year")]
        public decimal? ForecastQ4CurYear { get; set; }

        [JsonProperty("expenditures_q4_cur_year")]
        public decimal? ExpendituresQ4CurYear { get; set; }

        [JsonProperty("forecast_expenditures_cur_year")]
        public decimal? ForecastExpendituresCurYear { get; set; }

        [JsonProperty("cumulative_expenditures")]
        public decimal? CumulativeExpenditures { get; set; }

        [JsonProperty("design_award_date")]
        public DateTime? DesignAwardDate { get; set; }

        [JsonProperty("supervision_award_date")]
        public DateTime? SupervisionAwardDate { get; set; }

        [JsonProperty("contractor_award_date")]
        public DateTime? ContractorAwardDate { get; set; }

        [JsonProperty("original_planned_com_date")]
        public DateTime? OriginalPlannedComDate { get; set; }

        [JsonProperty("actual_forecast_com_date")]
        public DateTime? ActualForecastComDate { get; set; }

        [JsonProperty("original_progress")]
        public decimal? OriginalProgress { get; set; }

        [JsonProperty("revised_progress")]
        public decimal? RevisedProgress { get; set; }

        [JsonProperty("actual_progress")]
        public decimal? ActualProgress { get; set; }

        [MaxLength(500)]
        [JsonProperty("challenges")]
        public string Challenges { get; set; }

        [MaxLength(500)]
        [JsonProperty("measures")]
        public string Measures { get; set; }

        [MaxLength(150)]
        [JsonProperty("location")]
        public string Location { get; set; }

        [MaxLength(150)]
        [JsonProperty("design_name")]
        public string DesignName { get; set; }

        [MaxLength(300)]
        [JsonProperty("design_lic_no")]
        public string DesignLicNo { get; set; }

        [MaxLength(150)]
        [JsonProperty("supervision_name")]
        public string SupervisionName { get; set; }

        [MaxLength(300)]
        [JsonProperty("supervision_license_no")]
        public string SupervisionLicenseNo { get; set; }

        [MaxLength(150)]
        [JsonProperty("contractor_name")]
        public string ContractorName { get; set; }

        [MaxLength(300)]
        [JsonProperty("contractor_lic_no")]
        public string ContractorLicNo { get; set; }

        [MaxLength(150)]
        [JsonProperty("pm_name")]
        public string PmName { get; set; }

        [MaxLength(150)]
        [JsonProperty("pm_phone_no")]
        public string PmPhoneNo { get; set; }

        [MaxLength(150)]
        [JsonProperty("pm_email")]
        public string PmEmail { get; set; }

        [MaxLength(500)]
        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("start_year")]
        public int? StartYear { get; set; }

        [JsonIgnore]
        public DateTime EtlDate { get; set; }

        [JsonIgnore]
        public int CurrentYear { get; set; }
    }

}