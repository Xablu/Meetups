using System;
using MvvmCross.Binding.Bindings.Target;

namespace CustomBinding.iOS
{
	public class BinaryEditTargetBinding
		: MvxConvertingTargetBinding
	{
		private BinaryEdit _target;

		public BinaryEditTargetBinding(BinaryEdit target)
			: base(target)
		{
			_target = target;
		}

		public override void SubscribeToEvents()
		{
			base.SubscribeToEvents();

			_target.MyCountChanged += Target_CountChanged;
		}

		private void Target_CountChanged(object sender, EventArgs e)
		{
			if (_target == null) return;

			var count = _target.GetCount();
			FireValueChanged(count);
		}

		protected override void SetValueImpl(object target, object value)
		{
			_target.SetThat((int)value);
		}

		public override Type TargetType
		{
			get
			{
				return typeof(int);
			}
		}

		public override MvvmCross.Binding.MvxBindingMode DefaultMode
		{
			get
			{
				return MvvmCross.Binding.MvxBindingMode.TwoWay;
			}
		}

		protected override void Dispose(bool isDisposing)
		{
			if (isDisposing)
			{
				if (_target != null)
				{
					_target.MyCountChanged -= Target_CountChanged;
				}
			}

			base.Dispose(isDisposing);
		}
	}
}
