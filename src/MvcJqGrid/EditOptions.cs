using MvcJqGrid.Extensions;

namespace MvcJqGrid
{
    public class EditOptions
    {
        /// <summary>
        /// 	When set for edittype checkbox this value should be a string with two possible values separated with a colon (:) - Example editoptions:{value:“Yes:No”} where the first value determines the checked property.
        ///When set for edittype select value can be a string, object or function.
        ///If the option is a string it must contain a set of value:label pairs with the value separated from the label with a colon (:) and ended with(;). The string should not ended with a (;)- editoptions:{value:“1:One;2:Two”}.
        ///If set as object it should be defined as pair name:value - editoptions:{value:{1:'One';2:'Two'}}
        ///When defined as function - the function should return either formated string or object.
        ///In all other cases this is the value of the input element if defined.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// This option is valid only for elements of type select - i.e., edittype:select and should be the URL to get the AJAX data for the select element. The data is obtained via an AJAX call and should be a valid HTML select element with the desired options <select><option value='1'>One</option>…</select>. You can use option group.
        ///The AJAX request is called only once when the element is created.
        ///In the inline edit or the cell edit module it is called every time when you edit a new row or cell. In the form edit module only once.
        /// </summary>
        public string DataUrl { get; set; }

        /// <summary>
        /// This option is relevant only if the dataUrl parameter is set. When the server response can not build the select element, you can use your own function to build the select. The function should return a string containing the select and options value(s) as described in dataUrl option. Parameter passed to this function is the server response
        /// </summary>
        public string BuildSelect { get; set; }

        /// <summary>
        /// We pass the element object to this function, if defined. This function is called only once when the element is created. Example :
        ///…editoptions: { dataInit : function (elem) {
        ///$(elem).autocomplete();
        ///}
        ///}
        ///The event is called only once when the element is created.
        ///In the inline edit or the cell edit module it is called every time when you edit a new row or cell. In the form edit module only once if the recreateForm option is set to false, or every time if the same option is set to true .
        ///Note: Some plugins require the position of the element in the DOM and since this event is raised before inserting the element into the DOM you can use a setTimeout function to accomplish the desired action. This is especially valid for jQuery UI datepicker (1.7.x and up releases)
        /// </summary>
        public string DataInit { get; set; }

        /// <summary>
        /// 	list of events to apply to the data element; uses $(”#id”).bind(type, [data], fn) to bind events to data element. Should be described like this:
        ///… editoptions: { dataEvents: [
        ///{ type: 'click', data: { i: 7 }, fn: function(e) { console.log(e.data.i); } },
        ///{ type: 'keypress', fn: function(e) { console.log('keypress'); } }
        ///]
        ///} 
        /// </summary>
        public string DataEvents { get; set; }

        /// <summary>
        /// The option can be string or function. This option is valid only in Form Editing module when used with editGridRow method in add mode. If defined the input element is set with this value if only element is empty. If used in selects the text should be provided and not the key. Also when a function is used the function should return value.
        /// </summary>
        public string DefaultValue { get; set; }

        /// <summary>
        /// If set to true a string 'null' is send to the server when the data in that field is empty
        /// </summary>
        public bool? NullIfEmpty { get; set; }

        /// <summary>
        /// In this case you can set any other valid attribute for the editable element. For example, if the element is edittype:'text', we can set size, maxlength, etc. attributes. Refer to the valid attributes for the element
        /// </summary>
        public string OtherOptions { get; set; }

        public override string ToString()
        {
            return this.ToJSON();
        }
    }
}
