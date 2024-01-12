import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CreateCounterComponent } from './createhouse/create.house';
import { ListhouseComponent } from './listhouse/house.component';
import { ListRoleComponent } from './listrole/role.component';
import { CreateRoleComponent } from './createrole/create.role';
import { EditRoleComponent } from './editrole/edit.role';
import { EditHouseComponent } from './edithouse/edit.house';
import { ListCustomerComponent } from './listcustomer/customer.component';
import { CreateCustomerComponent } from './createcustomer/create.customer';
import { EditCustomerComponent } from './editcustomer/edit.customer';
import { ListOrderComponent } from './listorder/order.component';
import { CreateOrderComponent } from './createorder/create.order';
import { EditOrderComponent } from './editorder/edit.order';
import { UserComponent } from './user/user';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CreateCounterComponent,
    ListhouseComponent,
    ListRoleComponent,
    CreateRoleComponent,
    EditRoleComponent,
    EditHouseComponent,
    ListCustomerComponent,
    CreateCustomerComponent,
    EditCustomerComponent,
    ListOrderComponent,
    CreateOrderComponent,
    EditOrderComponent,
    UserComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'createhouse', component: CreateCounterComponent,},
      { path: 'listhouse', component: ListhouseComponent },
      { path: 'listrole', component: ListRoleComponent },
      { path: 'createrole', component: CreateRoleComponent },
      { path: 'editrole/:roleId', component: EditRoleComponent },
      { path: 'edithouse/:houseId', component: EditHouseComponent },
      { path: 'listcustomer', component: ListCustomerComponent },
      { path: 'createcustomer', component: CreateCustomerComponent },
      { path: 'editcustomer/:customerId', component: EditCustomerComponent },
      { path: 'listorder', component: ListOrderComponent },
      { path: 'createorder', component: CreateOrderComponent },
      { path: 'editorder/:orderId', component: EditOrderComponent },
      { path: 'user', component: UserComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
