using Newtonsoft.Json;

namespace GSECDataLoaderService.Model
{
    public class TableFeature_
    {
        public TableAttributes_ Attributes { get; set; }
    }

    public class TableAttributes_
    {
        [JsonProperty("project_id")]
        public string ProjectId { get; set; }

        [JsonProperty("entity_id")]
        public int? EntityId { get; set; }

        [JsonProperty("project_category_id")]
        public int? CategoryId { get; set; }

        [JsonProperty("project_phase_id")]
        public int? PhaseId { get; set; }

        [JsonProperty("project_status_id")]
        public int? StatusId { get; set; }

        [JsonProperty("pm_nationality_id")]
        public int? PmNationalityId { get; set; }

        [JsonProperty("dof_no")]
        public string DofNo { get; set; }

        private string _projectName;
        [JsonProperty("project_name")]
        public string ProjectName
        {
            get { return _projectName; }
            set
            {
                _projectName = value?.Length > 300 ? value?.Remove(300) : value;
            }
        }

        private string _projectDescription;
        [JsonProperty("project_description")]
        public string ProjectDescription
        {
            get { return _projectDescription; }
            set
            {
                _projectDescription = value?.Length > 500 ? value?.Remove(500) : value;
            }
        }

        private string _projectElements;
        [JsonProperty("project_elements")]
        public string ProjectElements
        {
            get { return _projectElements; }
            set
            {
                _projectElements = value?.Length > 300 ? value?.Remove(300) : value;
            }
        }

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
        public long? ResolutionDate { get; set; }

        [JsonProperty("resolution_recvd_date")]
        public long? ResolutionRecvdDate { get; set; }

        [JsonProperty("forecast_q1_cur_year")]
        public decimal? ForecastQ1CurYear { get; set; }

        [JsonProperty("expenditures_q1_cur_year")]
        public decimal? ExpendituresQ1CurYear { get; set; }

        private string _achievedMilestones;
        [JsonProperty("achieved_milestones")]
        public string AchievedMilestones
        {
            get { return _achievedMilestones; }
            set
            {
                _achievedMilestones = value?.Length > 500 ? value?.Remove(500) : value;
            }
        }

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
        public long? DesignAwardDate { get; set; }

        [JsonProperty("supervision_award_date")]
        public long? SupervisionAwardDate { get; set; }

        [JsonProperty("contractor_award_date")]
        public long? ContractorAwardDate { get; set; }

        [JsonProperty("original_planned_com_date")]
        public long? OriginalPlannedComDate { get; set; }

        [JsonProperty("actual_forecast_com_date")]
        public long? ActualForecastComDate { get; set; }

        [JsonProperty("original_progress")]
        public decimal? OriginalProgress { get; set; }

        [JsonProperty("revised_progress")]
        public decimal? RevisedProgress { get; set; }

        [JsonProperty("actual_progress")]
        public decimal? ActualProgress { get; set; }

        private string _challenges;
        [JsonProperty("challenges")]
        public string Challenges
        {
            get { return _challenges; }
            set
            {
                _challenges = value?.Length > 500 ? value?.Remove(500) : value;
            }
        }

        private string _measures;
        [JsonProperty("measures")]
        public string Measures
        {
            get { return _measures; }
            set
            {
                _measures = value?.Length > 500 ? value?.Remove(500) : value;
            }
        }

        private string _location;
        [JsonProperty("location")]
        public string Location
        {
            get { return _location; }
            set
            {
                _location = value?.Length > 150 ? value?.Remove(150) : value;
            }
        }

        private string _designName;
        [JsonProperty("design_name")]
        public string DesignName
        {
            get { return _designName; }
            set
            {
                _designName = value?.Length > 150 ? value?.Remove(150) : value;
            }
        }

        private string _designLicNo;
        [JsonProperty("design_lic_no")]
        public string DesignLicNo
        {
            get { return _designLicNo; }
            set
            {
                _designLicNo = value?.Length > 300 ? value?.Remove(300) : value;
            }
        }

        private string _supervisionName;
        [JsonProperty("supervision_name")]
        public string SupervisionName
        {
            get { return _supervisionName; }
            set
            {
                _supervisionName = value?.Length > 150 ? value?.Remove(150) : value;
            }
        }

        private string _supervisionLicenseNo;
        [JsonProperty("supervision_license_no")]
        public string SupervisionLicenseNo
        {
            get { return _supervisionLicenseNo; }
            set
            {
                _supervisionLicenseNo = value?.Length > 300 ? value?.Remove(300) : value;
            }
        }

        private string _contractorName;
        [JsonProperty("contractor_name")]
        public string ContractorName
        {
            get { return _contractorName; }
            set
            {
                _contractorName = value?.Length > 150 ? value?.Remove(150) : value;
            }
        }

        private string _contractorLicNo;
        [JsonProperty("contractor_lic_no")]
        public string ContractorLicNo
        {
            get { return _contractorLicNo; }
            set
            {
                _contractorLicNo = value?.Length > 300 ? value?.Remove(300) : value;
            }
        }

        private string _pmName;
        [JsonProperty("pm_name")]
        public string PmName
        {
            get { return _pmName; }
            set
            {
                _pmName = value?.Length > 150 ? value?.Remove(150) : value;
            }
        }

        private string _pmPhoneNo;
        [JsonProperty("pm_phone_no")]
        public string PmPhoneNo
        {
            get { return _pmPhoneNo; }
            set
            {
                _pmPhoneNo = value?.Length > 150 ? value?.Remove(150) : value;
            }
        }

        private string _pmEmail;
        [JsonProperty("pm_email")]
        public string PmEmail
        {
            get { return _pmEmail; }
            set
            {
                _pmEmail = value?.Length > 150 ? value?.Remove(150) : value;
            }
        }

        private string _note;
        [JsonProperty("note")]
        public string Note
        {
            get { return _note; }
            set
            {
                _note = value?.Length > 500 ? value?.Remove(500) : value;
            }
        }

        [JsonProperty("start_year")]
        public int? StartYear { get; set; }
    }


}
