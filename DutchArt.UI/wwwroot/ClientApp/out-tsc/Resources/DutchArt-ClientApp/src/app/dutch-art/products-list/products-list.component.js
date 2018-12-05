import * as tslib_1 from "tslib";
import { Component } from '@angular/core';
import { DutchArtService } from '../../shared/services/dutch-art.service';
var ProductsListComponent = /** @class */ (function () {
    function ProductsListComponent(service) {
        this.service = service;
        this.Products = [];
    }
    ProductsListComponent.prototype.ngOnInit = function () {
        this.GetProductsList();
    };
    ProductsListComponent.prototype.GetProductsList = function () {
        var _this = this;
        this.service.getData().subscribe(function (data) {
            _this.Products = data.products;
        });
    };
    ProductsListComponent = tslib_1.__decorate([
        Component({
            selector: 'app-products-list',
            templateUrl: './products-list.component.html',
            styleUrls: ['./products-list.component.css']
        }),
        tslib_1.__metadata("design:paramtypes", [DutchArtService])
    ], ProductsListComponent);
    return ProductsListComponent;
}());
export { ProductsListComponent };
//# sourceMappingURL=products-list.component.js.map