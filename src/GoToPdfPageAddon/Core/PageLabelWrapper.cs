namespace GoToPdfPage
{
    public class PageLabelWrapper
    {
        #region Properties

        public bool HasLogicalNumber { get; set; }

        public int PhysicalNumber { get; set; }

        public string LogicalNumber { get; set; }

        #endregion

        #region Methods

        public override string ToString()
        {
            return HasLogicalNumber
                ? LogicalNumber
                : PhysicalNumber.ToString();
        }

        #endregion
    }
}
