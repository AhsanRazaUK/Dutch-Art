import * as tslib_1 from "tslib";
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import 'rxjs/Rx';
var DutchArtService = /** @class */ (function () {
    function DutchArtService(http) {
        this.http = http;
        this.apiUrl = "../../../assets/DutchArt.json";
    }
    DutchArtService.prototype.getData = function () {
        return this.http.get(this.apiUrl);
    };
    DutchArtService = tslib_1.__decorate([
        Injectable(),
        tslib_1.__metadata("design:paramtypes", [HttpClient])
    ], DutchArtService);
    return DutchArtService;
}());
export { DutchArtService };
//# sourceMappingURL=dutch-art.service.js.map