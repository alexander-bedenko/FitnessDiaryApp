"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var operators_1 = require("rxjs/operators");
var _services_1 = require("../_services");
var modal_component_1 = require("./modal.component");
var HomeComponent = /** @class */ (function () {
    function HomeComponent(userService, modalService) {
        this.userService = userService;
        this.modalService = modalService;
        this.users = [];
        this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
    }
    HomeComponent_1 = HomeComponent;
    HomeComponent.prototype.ngOnInit = function () {
        this.loadAllUsers();
    };
    HomeComponent.prototype.openModal = function () {
        var modalRef = this.modalService.activeModal.open(HomeComponent_1);
        modalRef.componentInstance.content = this.loadAllUsers();
    };
    HomeComponent.prototype.deleteUser = function (id) {
        var _this = this;
        this.userService.delete(id).pipe(operators_1.first()).subscribe(function () {
            _this.loadAllUsers();
        });
    };
    HomeComponent.prototype.loadAllUsers = function () {
        var _this = this;
        this.userService.getAll().pipe(operators_1.first()).subscribe(function (users) {
            _this.users = users;
        });
    };
    __decorate([
        core_1.Input(),
        __metadata("design:type", Object)
    ], HomeComponent.prototype, "content", void 0);
    HomeComponent = HomeComponent_1 = __decorate([
        core_1.Component({ templateUrl: 'home.component.html' }),
        __metadata("design:paramtypes", [_services_1.UserService, modal_component_1.NgbdModalComponent])
    ], HomeComponent);
    return HomeComponent;
    var HomeComponent_1;
}());
exports.HomeComponent = HomeComponent;
//# sourceMappingURL=home.component.js.map