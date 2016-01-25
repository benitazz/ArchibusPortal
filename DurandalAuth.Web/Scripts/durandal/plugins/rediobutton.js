/**
 * Durandal 2.0.1 Copyright (c) 2012 Blue Spire Consulting, Inc. All Rights Reserved.
 * Available via the MIT license.
 * see: http://durandaljs.com or https://github.com/BlueSpire/Durandal for details.
 */
/**
 * Layers the widget sugar on top of the composition system.
 * @module widget
 * @requires system
 * @requires composition
 * @requires jquery
 * @requires knockout
 */
define(['durandal/system', 'durandal/composition', 'jquery', 'knockout'], function(system, composition, $, ko) {
    ko.bindingHandlers.bsChecked = {
        init: function(element, valueAccessor, allBindingsAccessor,
            viewModel, bindingContext) {
            var value = valueAccessor();
            var newValueAccessor = function() {
                return {
                    change: function() {
                        value(element.value);
                    }
                }
            };
            ko.bindingHandlers.event.init(element, newValueAccessor,
                allBindingsAccessor, viewModel, bindingContext);
        },
        update: function(element, valueAccessor, allBindingsAccessor,
            viewModel, bindingContext) {
            if ($(element).val() == ko.unwrap(valueAccessor())) {
                setTimeout(function() {
                    $(element).closest('.btn').button('toggle');
                }, 1);
            }
        }
    };

    $(function () {
        var viewModel = {
            // data
            items: ko.observableArray([]),
            itemToAdd: ko.observable(""),

            // behaviors
            addItem: function () {
                this.items.push({ name: this.itemToAdd() });
                this.itemToAdd("");
            }
        };
        ko.applyBindings(viewModel);
    });
})