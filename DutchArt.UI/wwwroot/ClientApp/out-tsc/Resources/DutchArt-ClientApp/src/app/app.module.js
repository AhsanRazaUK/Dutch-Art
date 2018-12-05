import * as tslib_1 from "tslib";
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './shared/ui/header/header.component';
import { ContentComponent } from './shared/ui/content/content.component';
import { FooterComponent } from './shared/ui/footer/footer.component';
import { ProductsListComponent } from './dutch-art/products-list/products-list.component';
import { DutchArtService } from './shared/services/dutch-art.service';
import { HttpClientModule } from '@angular/common/http';
var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = tslib_1.__decorate([
        NgModule({
            declarations: [
                AppComponent,
                HeaderComponent,
                ContentComponent,
                FooterComponent,
                ProductsListComponent
            ],
            imports: [
                BrowserModule,
                AppRoutingModule,
                HttpClientModule
            ],
            providers: [DutchArtService],
            bootstrap: [AppComponent]
        })
    ], AppModule);
    return AppModule;
}());
export { AppModule };
//# sourceMappingURL=app.module.js.map