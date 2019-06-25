using Util.Helpers;

namespace GreatWall.Domain.Models {
    /// <summary>
    /// 角色
    /// </summary>
    public partial class Role {
        /// <summary>
        /// 初始化
        /// </summary>
        public override void Init() {
            base.Init();
            InitPinYin();
        }

        /// <summary>
        /// 初始化拼音简码
        /// </summary>
        public void InitPinYin() {
            PinYin = String.PinYin( Name );
        }
    }
}