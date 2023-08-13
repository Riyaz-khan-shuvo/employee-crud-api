using Employment.Sheared.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Employment.Service.Models.ViewModel
{
	public class VMEmployee:IVM
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
		public int Id { get; set; }
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		public string Name { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the address.
		/// </summary>
		/// <value>
		/// The address.
		/// </value>
		public string Address { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the gender.
		/// </summary>
		/// <value>
		/// The gender.
		/// </value>
		public string Gender { get; set; } = string.Empty;


		/// <summary>
		/// Gets or sets the department identifier.
		/// </summary>
		/// <value>
		/// The department identifier.
		/// </value>
		public int DepartmentId { get; set; }
		/// <summary>
		/// Gets or sets the joining date.
		/// </summary>
		/// <value>
		/// The joining date.
		/// </value>
		public DateTime JoiningDate { get; set; }
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Employee"/> is SSC.
		/// </summary>
		/// <value>
		///   <c>true</c> if SSC; otherwise, <c>false</c>.
		/// </value>
		public Boolean Ssc { get; set; }
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Employee"/> is HSC.
		/// </summary>
		/// <value>
		///   <c>true</c> if HSC; otherwise, <c>false</c>.
		/// </value>
		public Boolean Hsc { get; set; }
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Employee"/> is BSC.
		/// </summary>
		/// <value>
		///   <c>true</c> if BSC; otherwise, <c>false</c>.
		/// </value>
		public Boolean Bsc { get; set; }
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Employee"/> is MSC.
		/// </summary>
		/// <value>
		///   <c>true</c> if MSC; otherwise, <c>false</c>.
		/// </value>
		public Boolean Msc { get; set; }

		/// <summary>
		/// Gets or sets the picture.
		/// </summary>
		/// <value>
		/// The picture.
		/// </value>
		public string Picture { get; set; } = string.Empty;
		/// <summary>
		/// Gets or sets the country identifier.
		/// </summary>
		/// <value>
		/// The country identifier.
		/// </value>
		public int CountryId { get; set; }


		/// <summary>
		/// Gets or sets the state identifier.
		/// </summary>
		/// <value>
		/// The state identifier.
		/// </value>
		public int StateId { get; set; }

		/// <summary>
		/// Gets or sets the city identifier.
		/// </summary>
		/// <value>
		/// The city identifier.
		/// </value>
		public int CityId { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
      

        public VMCountry? Country { get; set; }
        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
       

        public VMState? State { get; set; }
        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
      
        public VMCity? City { get; set; }
		/// <summary>
		/// Gets or sets the department.
		/// </summary>
		/// <value>
		/// The department.
		/// </value>
		
		public VMDepartment? Department { get; set; }

	}
}
