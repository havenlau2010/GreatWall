import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { EditComponentBase } from '../../../util';
import { ApplicationViewModel } from './model/application-view-model';

/**
 * 应用程序编辑页
 */
@Component({
    selector: 'application-edit',
    templateUrl: !env.dev() ? './html/application-edit.component.html' : '/view/systems/application/edit'
})
export class ApplicationEditComponent extends EditComponentBase<ApplicationViewModel> {
    /**
     * 初始化应用程序编辑页
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        super(injector);
    }

    /**
     * 创建模型
     */
    protected createModel() {
        let result = new ApplicationViewModel();
        result.enabled = true;
        result.registerEnabled = true;
        return result;
    }

    /**
     * 获取基地址
     */
    protected getBaseUrl() {
        return "application";
    }
}