�I�C��,qP3��2 ���T��6�<�)kS7g�$�E�<M��NHy�Xw�)�II�#'��[C��IX��Z�,�G�xS�{8j���g���G��T��h���#��D�#u���e��BXi���Do��A�<'T�����5���r��Z��T���7>w�3R��9-�(PKK�8S)��*�����M*�Œ��a���0�>�m(�&�ro@�45� 6��W�锈�jbE�؜��J`���=�VY�A�S��:|uu�l[��Z2�[�*�B��0�m|���@#�т(�a�n�i���uP��v K���NjB��pl���~uO�Ç�Ah�WHP�ˬ��v x�%���� hL/9���O�n��μ�t��f��5��YU�93d+4�]��s�;\ґ�*��*e-���5FH���)0��t}:�2�{D�`S�4J�~�ʠ"ytS�_�|4+�z�S��0|��:�Bl�ct!��QMy�'Rk�Y��JXM
[��-��$�4��V��K�V��D�����}s�-��{ztName = "current_state")]
        public string CurrentState { get; set; }

        [XmlElement(ElementName = "owned_by")]
        public string OwnedBy { get; set; }

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "story_type")]
        public string Type { get; set; }

        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        [XmlElement(ElementName = "requested_by")]
        public string RequestedBy { get; set; }

        [XmlElement(ElementName = "created_at")]
        public string CreatedAt { get; set; }

        [XmlElement(ElementName = "accepted_at")]
        public string AcceptedAt { get; set; }

        [XmlElement(ElementName = "labels")]
        public string Labels { get; set; }

		[XmlElement(ElementName = "priority")]
		public int Priority { get; set; }

    }
}
